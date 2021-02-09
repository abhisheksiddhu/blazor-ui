using Arinsys.AspNetCore.Components.Samples.Models;

using Bogus;

using System;

namespace Arinsys.AspNetCore.Components.Samples.Fakes
{
    public static class FakeUser
    {
        public static Faker<User> ValidDefaults => new Faker<User>()
            .RuleFor(o => o.Id, _ => Guid.NewGuid())
            .RuleFor(o => o.Name, f => f.Name.FullName())
            .RuleFor(o => o.Email, f => f.Internet.Email());
    }
}
