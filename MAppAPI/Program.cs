using MApp.Common.Helpers;
using MApp.DataAccess.Context;
using MApp.DataAccess.DataAccessors.ContactInvitationsAccessors;
using MApp.DataAccess.DataAccessors.EventsStatusesAccessors;
using MApp.DataAccess.DataAccessors.OnlineEventsAccessors;
using MApp.DataAccess.DataAccessors.OnlineEventsInvitationsAccessors;
using MApp.DataAccess.DataAccessors.PhysicalEventsAccessors;
using MApp.DataAccess.DataAccessors.PhysicalEventsInvitationsAccessors;
using MApp.DataAccess.DataAccessors.UsersAccessors;
using MApp.DataAccess.DataModifiers.EventsStatusesModifiers;
using MApp.DataAccess.DataModifiers.OnlineEventsModifiers;
using MApp.DataAccess.DataModifiers.PhysicalEventsModifiers;
using MApp.DataAccess.DataModifiers.UsersModifiers;
using MAppAPI.ControllersServices.EventsStatusesServices;
using MAppAPI.ControllersServices.OnlineEventsServices;
using MAppAPI.ControllersServices.PhysicalEventsServices;
using MAppAPI.ControllersServices.UsersServices;
using MAppAPI.Validators.EventsStatusesValidators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
         ClockSkew = TimeSpan.Zero
     };
 });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



/*builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = FacebookDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = FacebookDefaults.AuthenticationScheme;
})
.AddFacebook(options =>
{
    options.AppId = "YourAppId";
    options.AppSecret = "YourAppSecret";
});*/

//builder.Services.AddSingleton<LoggedUsersService>();
builder.Services.AddDbContext<MAppDbContext>();

#region Data Accessors
builder.Services.AddTransient<ContactInvitationAccessor>();

builder.Services.AddTransient<EventStatusAccessor>();

builder.Services.AddTransient<OnlineEventAccessor>();

builder.Services.AddTransient<OnlineEventInvitationAccessor>();

builder.Services.AddTransient<PhysicalEventAccessor>();

builder.Services.AddTransient<PhysicalEventInvitationAccessor>();

builder.Services.AddTransient<UserAccessor>();
builder.Services.AddTransient<UserWithContactInvitationsAccessor>();
builder.Services.AddTransient<UserWithContactsAccessor>();
builder.Services.AddTransient<UserWithOnlineEventsAccessor>();
builder.Services.AddTransient<UserWithOnlineEventsInvitationsAccessor>();
builder.Services.AddTransient<UserWithPhysicalEventsAccessor>();
builder.Services.AddTransient<UserWithPhysicalEventsInvitationsAccessor>();
#endregion

#region Data Modifiers And Creators
builder.Services.AddTransient<EventStatusModifier>();
builder.Services.AddTransient<StatusCommentModifier>();

builder.Services.AddTransient<OnlineEventAttendeesModifier>();
builder.Services.AddTransient<OnlineEventCreator>();
builder.Services.AddTransient<OnlineEventInvitationsModifier>();

builder.Services.AddTransient<PhysicalEventAttendeesModifier>();
builder.Services.AddTransient<PhysicalEventCreator>();
builder.Services.AddTransient<PhysicalEventInvitationsModifier>();

builder.Services.AddTransient<ContactInvitationsModifier>();
builder.Services.AddTransient<ContactsModifier>();
builder.Services.AddTransient<UserProfileModifier>();
#endregion

#region Controllers Services
builder.Services.AddTransient<EventStatusCommentsService>();
builder.Services.AddTransient<OnlineEventStatusCreationService>();
builder.Services.AddTransient<PhysicalEventStatusCreationService>();

builder.Services.AddTransient<OnlineEventAttendeesService>();
builder.Services.AddTransient<OnlineEventCreationService>();
builder.Services.AddTransient<OnlineEventInfoService>();

builder.Services.AddTransient<PhysicalEventAttendeesService>();
builder.Services.AddTransient<PhysicalEventCreationService>();
builder.Services.AddTransient<PhysicalEventInfoService>();

builder.Services.AddTransient<ContactsService>();
builder.Services.AddTransient<ContactInvitationsService>();
builder.Services.AddTransient<UserProfileService>();
#endregion

builder.Services.AddTransient<JWTHelper>();
builder.Services.AddTransient<UserAttendanceValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
