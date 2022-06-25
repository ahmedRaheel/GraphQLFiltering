using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL {

    // Object type comes from HotChocolate.Types to map business logic model and GQL types
    public class PlatformType : ObjectType<Platform> {
        protected override void Configure (IObjectTypeDescriptor<Platform> descriptor) {
            descriptor.Description ("Represents any software or service that has a command line interface");

            // Ignore field prevents exposing a fiedl to the public gql api
            descriptor.Field (e => e.LicenseKey).Ignore ();

            descriptor
                .Field (e => e.Commands)
                .ResolveWith<Resolvers> (e => e.GetCommands (default !, default !))
                .UseDbContext<WebAppContext> ()
                .Description ("This is a list of commands for a particular platform");

            base.Configure (descriptor);
        }

        private class Resolvers {
            public IQueryable<Command> GetCommands ([Parent] Platform platform, [ScopedService] WebAppContext dbContext) {
                if (dbContext.Commands == null) return Enumerable.Empty<Command> ().AsQueryable ();

                return dbContext.Commands.Where (e => e.PlatformId == platform.Id);
            }
        }
    }
}