using System.Threading.Tasks;
using GraphQl.Common.Exceptions;
using GraphQl.Data;
using GraphQl.Extensions;
using GraphQl.Sessions;
using GraphQl.Speakers;
using GraphQl.Tracks;
using HotChocolate;

namespace GraphQl
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [ScopedService] ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
        [UseApplicationDbContext]

        public async Task<AddSessionPayload> AddSessionAsync(
          AddSessionInput input,
          [ScopedService] ApplicationDbContext context,
          CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Title))
            {
                return new AddSessionPayload(
                    new UserError("The title cannot be empty.", "TITLE_EMPTY"));
            }

            if (input.SpeakerIds.Count == 0)
            {
                return new AddSessionPayload(
                    new UserError("No speaker assigned.", "NO_SPEAKER"));
            }

            var session = new Session
            {
                Title = input.Title,
                Abstract = input.Abstract,
            };

            foreach (int speakerId in input.SpeakerIds)
            {
                session.SessionSpeakers.Add(new SessionSpeaker
                {
                    SpeakerId = speakerId
                });
            }

            context.Sessions.Add(session);
            await context.SaveChangesAsync(cancellationToken);

            return new AddSessionPayload(session);
        }

        [UseApplicationDbContext]
        public async Task<ScheduleSessionPayload> ScheduleSessionAsync(
        ScheduleSessionInput input,
        [ScopedService] ApplicationDbContext context)
        {
            if (input.EndTime < input.StartTime)
            {
                return new ScheduleSessionPayload(
                    new UserError("endTime has to be larger than startTime.", "END_TIME_INVALID"));
            }

            Session session = await context.Sessions.FindAsync(input.SessionId);

            if (session is null)
            {
                return new ScheduleSessionPayload(
                    new UserError("Session not found.", "SESSION_NOT_FOUND"));
            }

            session.TrackId = input.TrackId;
            session.StartTime = input.StartTime;
            session.EndTime = input.EndTime;

            await context.SaveChangesAsync();

            return new ScheduleSessionPayload(session);
        }


            [UseApplicationDbContext]
            public async Task<AddTrackPayload> AddTrackAsync(
                AddTrackInput input,
                [ScopedService] ApplicationDbContext context,
                CancellationToken cancellationToken)
            {
                var track = new Track { Name = input.Name };
                context.Tracks.Add(track);

                await context.SaveChangesAsync(cancellationToken);

                return new AddTrackPayload(track);
            }
        




        [UseApplicationDbContext]
        public async Task<RenameTrackPayload> RenameTrackAsync(
    RenameTrackInput input,
    [ScopedService] ApplicationDbContext context,
    CancellationToken cancellationToken)
        {
            Track track = await context.Tracks.FindAsync(input.Id);
            track.Name = input.Name;

            await context.SaveChangesAsync(cancellationToken);

            return new RenameTrackPayload(track);
        }























    }

}
