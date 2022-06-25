using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL {

    public class CommandType : ObjectType<Command> {
        protected override void Configure (IObjectTypeDescriptor<Command> descriptor) {
            descriptor.Description ("Represents any executable command for a platform");

            descriptor
                .Field (e => e.Platform)
                .ResolveWith<Resolvers> (e => e.GetPlatform (default !, default !))
                .UseDbContext<WebAppContext> ()
                .Description ("This is the platform to which the command belongs");

            base.Configure (descriptor);
        }

        private class Resolvers {
            // There was no argument with the name... 
            // https://stackoverflow.com/questions/69451691/there-was-no-argument-with-the-name-found-on-the-field        
            public Platform? GetPlatform ([Parent] Command command, [ScopedService] WebAppContext dbContext) {
                if (dbContext.Platforms == null) return null;

                return dbContext.Platforms.Where (e => e.Id == command.PlatformId).FirstOrDefault ();
            }
        }
    }
}