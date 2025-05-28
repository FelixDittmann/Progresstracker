using System.Threading.Tasks;
using Xunit;
using Moq;
using Progresstracker.Application.DataObjectHandler;
using Progresstracker.Domain.Repository_Interfaces;
using Progresstracker.Domain.DataObjects;

namespace Progresstracker.Tests
{
    public class CreateProfileTests
    {
        [Fact]
        public async Task CreateProfile_NoInput()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string emptyName = "";
            string emptyApiKey = "";
            string emptySteamId = "";

            // Act
            var result = await profileService.CreateProfile(emptyName, emptyApiKey, emptySteamId);

            // Assert
            Assert.False(result.Success);
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Profilname", result.ErrorMessage);
            Assert.DoesNotContain("Steam API Key", result.ErrorMessage);
            Assert.Contains("Steam ID", result.ErrorMessage);

            // Verifizieren, dass AddAsync niemals aufgerufen wurde
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Domain.DataObjects.UserProfile>()), Times.Never);
        }

        [Fact]
        public async Task CreateProfile_WrongInput()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string invalidName = "me";  // Leerzeichen oder ungültig
            string invalidApiKey = "xyz"; // Kein valider Key (je nach Definition)
            string invalidSteamId = "123456"; // Falsches Format

            // Act
            var result = await profileService.CreateProfile(invalidName, invalidApiKey, invalidSteamId);

            // Assert
            Assert.False(result.Success); // Die Erstellung darf nicht erfolgreich sein
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Profilname", result.ErrorMessage);
            Assert.Contains("API Key", result.ErrorMessage);
            Assert.Contains("Steam ID", result.ErrorMessage);

            // Verifizieren, dass AddAsync niemals aufgerufen wurde
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Domain.DataObjects.UserProfile>()), Times.Never);
        }

        [Fact]
        public async Task CreateProfile_ValidInput()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            mockRepo
                .Setup(r => r.AddAsync(It.IsAny<UserProfile>()))
                .Returns(Task.CompletedTask); // Simuliere erfolgreiche Speicherung

            var profileService = new ProfileService(mockRepo.Object);

            string validName = "TestUser";
            string validApiKey = "VALIDAPIKEY112233445566778899001";
            string validSteamID = "76561198000000000"; // Gültige SteamID64

            // Act
            var result = await profileService.CreateProfile(validName, validApiKey, validSteamID);

            // Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage); // Es sollte keine Fehlermeldung geben
            mockRepo.Verify(repo => repo.AddAsync(It.Is<UserProfile>(p =>
                p.Name == "TestUser" &&
                p.SteamApiKey == "VALIDAPIKEY112233445566778899001" &&
                p.SteamProfileID == "76561198000000000"
            )), Times.Once); // Sicherstellen, dass das Repository korrekt aufgerufen wurde
        }
    }
}