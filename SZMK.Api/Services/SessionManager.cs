using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web;
using SZMK.Domain.BindingModels;
using SZMK.Domain.Models;
using SZMK.Domain.Models.Response;
using SZMK.Domain.ViewModels;
using SZMK.Infrastructure.Cryptography;
using SZMK.Infrastructure.Data;

namespace SZMK.Api.Services
{
    public class SessionManager
    {
        readonly ApplicationContext context = new ApplicationContext();

        #region Получение
        public async Task<List<InfoSessionViewModel>> GetSessions(string login)
        {
            try
            {
                User user = await new UserManager().GetByLogin(login);

                if (user != null)
                {
                    List<InfoSessionViewModel> sessions = new List<InfoSessionViewModel>();

                    foreach (RefreshSession session in user.RefreshSessions)
                    {
                        sessions.Add(new InfoSessionViewModel { RefreshToken = new RFC().Decrypt(session.RefreshToken, session.Salt), IP = session.IP, ClientName = session.ClientName });
                    }

                    return sessions;
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Добавление
        public async Task<bool> AddSession(TokensViewModel token, LoginBindingModel login, string userIP)
        {
            try
            {
                User user = await new UserManager().GetByLogin(login.Login);

                if (user != null)
                {
                    if (user.RefreshSessions.Count < ConfigurationService.MaxCountSessions)
                    {
                        context.Users.Attach(user);
                        await context.RefreshSessions.AddAsync(new RefreshSession { DateCreate = DateTime.UtcNow, TimeExpired = DateTime.UtcNow.AddMonths(2), RefreshToken = new RFC().Encrypt(token.RefreshToken, login.Salt), Salt = login.Salt, IP = userIP, ClientName = login.ClientName, User = user });
                        await context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        throw new Exception(SessionExceptions.StringOutOfRangeSession);
                    }
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Обновление
        public async Task<TokensViewModel> RefreshSession(SessionBindingModel sessionModel, string userIP)
        {
            try
            {
                RefreshSession session = await context.RefreshSessions.Include(p => p.User).FirstOrDefaultAsync(p => p.RefreshToken == sessionModel.RefreshToken);


                if (session != null)
                {
                    if (session.TimeExpired > DateTime.UtcNow)
                    {
                        if (JwtManager.DeleteToken(sessionModel.RefreshToken))
                        {
                            TokensViewModel tokens = JwtManager.GenerateTokens(session.User.Login, session.Salt);
                            session.RefreshToken = new RFC().Encrypt(tokens.RefreshToken, session.Salt);
                            session.TimeExpired = DateTime.UtcNow.AddMonths(2);
                            session.IP = userIP;
                            await context.SaveChangesAsync();

                            return tokens;
                        }
                        else
                        {
                            throw new Exception("Ошибка удаления токенов пользователя");
                        }
                    }
                    else
                    {
                        JwtManager.DeleteToken(sessionModel.RefreshToken);
                        await DeleteSession(sessionModel);
                        throw new Exception("Сессия пользователя истекла");
                    }
                }
                else
                {
                    throw new Exception("Не найдена сессия пользователя");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
        #endregion

        #region Удаление
        public async Task<bool> DeleteSession(SessionBindingModel sessionModel)
        {
            try
            {
                RefreshSession session = await context.RefreshSessions.FirstOrDefaultAsync(p => p.RefreshToken == sessionModel.RefreshToken);

                context.RefreshSessions.Remove(session);

                JwtManager.DeleteToken(session.RefreshToken);

                await context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteSession(InfoSessionBindingModel infoSessionModel)
        {
            try
            {
                User user = await new UserManager().GetByLogin(infoSessionModel.Login);

                RefreshSession session = user.RefreshSessions.FirstOrDefault(p => p.RefreshToken == new RFC().Encrypt(infoSessionModel.RefreshToken, p.Salt));

                context.RefreshSessions.Remove(session);

                JwtManager.DeleteToken(session.RefreshToken);

                await context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}