﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Infrastructure
{
    //public class CustomPasswordValidator : IPasswordValidator<AppUser>
    //{
    //    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
    //    {
    //        List<IdentityError> errors = new List<IdentityError>();
    //        if (password.ToLower().Contains(user.UserName.ToLower()))
    //        {
    //            errors.Add(new IdentityError
    //            {
    //                Code = "PasswordContainsUserName",
    //                Description = "Password cannot contain username"
    //            });
    //        }
    //        if (password.Contains("12345"))
    //        {
    //            errors.Add(new IdentityError
    //            {
    //                Code = "PasswordContainsSequence",
    //                Description = "Password cannot contain numeric sequence"
    //            });
    //        }
    //        return Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
    //    }
    //}
    public class CustomPasswordValidator : PasswordValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager,user, password);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Password cannot contain username"
                });
            }
            if (password.Contains("12345"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSequence",
                    Description = "Password cannot contain numeric sequence"
                });
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
