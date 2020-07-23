using System.Collections.Generic;
using gamocracy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace gamocracy.Services
{
    public static class DatabaseSeeder
    {
        public async static void SeedAsync(UserManager<IdentityUser> _userManager)
        {
            var user = await _userManager.FindByEmailAsync("test@test.com");
            if (user == null)
            {
                user = new IdentityUser { UserName = "TestUser", Email = "test@test.com", EmailConfirmed = true };
                await _userManager.CreateAsync(user, "Test1.");
                user = await _userManager.FindByEmailAsync(user.Email);
            }

            using (var context = new GamocracyContext())
            {
                if (await context.Stories.CountAsync() == 0)
                {
                    context.Stories.AddRange(StoriesToSeed(user));
                    context.SaveChanges();
                }
            } 
        }

        private static List<Story> StoriesToSeed(IdentityUser user)
        {
            var story1 = new Story()
            {
                Title = "Anna Karenina",
                Summary = "You play as Anna Karenina, a sophisticated woman. Will you abandon your empty existence as the wife of Karenin and turns to Count Vronsky to fulfil her passionate nature?",
                CreatedBy = user.UserName,
                StartingScene = new Scene()
            };

            var story2 = new Story()
            {
                Title = "To Kill a Mockingbird",
                Summary = "You play as Atticus Finch and must defend an innocent man!",
                CreatedBy = user.UserName,
                StartingScene = new Scene()
            };

            var story3 = new Story()
            {
                Title = "The Great Gatsby",
                Summary = "You play as Jay Gatsy. Can you throw one hell of a party?",
                CreatedBy = user.UserName,
                StartingScene = new Scene()

            };

            var story4 = new Story()
            {
                Title = "One Hundred Years of Solitude",
                Summary = "You play as José Arcadio Buendía, found the town of Macondo, Colombia!",
                CreatedBy = user.UserName,
                StartingScene = new Scene()

            };

            var story5 = new Story()
            {
                Title = "A Passage to India",
                Summary = "You play as Dr. Aziz, defend your innocence!",
                CreatedBy = user.UserName,
                StartingScene = new Scene()

            };

            var story6 = new Story()
            {
                Title = "Don Quixote",
                Summary = "You play as Don Quixote, you are definitely a real knight.",
                CreatedBy = user.UserName,
                StartingScene = new Scene()

            };

            var story7 = new Story()
            {
                Title = "Mrs. Dalloway",
                Summary = "You play as Clarissa Dalloway, prepair to host a party!",
                CreatedBy = user.UserName,
                StartingScene = new Scene()

            };

            var story8 = new Story()
            {
                Title = "Things Fall Apart",
                Summary = "You play as Okonkwo, famous in the villages of Umuofia for being a wrestling champion. Dispel your father Unoka's tainted legacy!",
                CreatedBy = user.UserName,
                StartingScene = new Scene()

            };

            var story9 = new Story()
            {
                Title = "Jane Eyre",
                Summary = "Come of age!",
                CreatedBy = user.UserName,
                StartingScene = new Scene()

            };

            var story10 = new Story()
            {
                Title = "The Yellow Wallpaper",
                Summary = "Descend into madness!",
                CreatedBy = user.UserName,
                StartingScene = new Scene()

            };

            return new List<Story>() { story1, story2, story3, story4, story5, story6, story7, story8, story9, story10 };

        }
    }
}