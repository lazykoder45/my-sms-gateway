using Microsoft.Extensions.Configuration;
using MySmsGateway.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MySmsGateway.Dao
{
    public class UserDao : CommonDao
    {
        public UserDao(IConfiguration configuration) : base(configuration)
        {
        }

        public UserInfo GetByEmailId(string emailId)
        {
            var sql = "select * from UserInfo where Email = @emailId ;";
            using (var db = GetDbConnection())
            {
                return db.Query<UserInfo>(sql, new { emailId }).FirstOrDefault();
            }
        }

        public bool InsertNewUserInfo(UserInfo obj)
        {
            var sql = @"INSERT INTO UserInfo(Email,PasswordHash,Name,MobileNo,IsEmailVerified,CreateAt
            ,PasswordResetToken,PasswordResetTokenExpiry,VerificationToken,VerificationTokenExpiry)
            VALUES(@Email,@PasswordHash,@Name,@MobileNo,@IsEmailVerified,@CreateAt
            ,@PasswordResetToken,@PasswordResetTokenExpiry,@VerificationToken,@VerificationTokenExpiry);";
            using (var db = GetDbConnection())
            {
                return db.Execute(sql, obj) > 0;
            }
        }
    }
}
