using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebAPINetCore8.Repos;
using WebAPINetCore8.Repos.Models;
using WebAPINetCore8.Service;

namespace WebAPINetCore8.Container
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly LearndataContext _context;

        public RefreshHandler(LearndataContext context)
        {
            this._context = context;
        }

        public async Task<string> GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using(var randomnumbergenerator = RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string refreshtoken = Convert.ToBase64String(randomnumber);
                var Existtoken = await this._context.TblRefreshtokens.FirstOrDefaultAsync(item => item.Userid == username);
                if (Existtoken != null)
                {
                    Existtoken.Refreshtoken = refreshtoken;
                }
                else
                {
                    await this._context.TblRefreshtokens.AddAsync(new TblRefreshtoken
                    {
                        Userid = username,
                        Tokenid = new Random().Next().ToString(),
                        Refreshtoken = refreshtoken
                    });
                }
                await this._context.SaveChangesAsync();

                return refreshtoken;
            }
        }
    }
}
