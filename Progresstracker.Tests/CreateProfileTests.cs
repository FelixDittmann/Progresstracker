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
        public async Task CreateProfile_NoInput_WrongApiKey()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string emptyName = "";
            string invalidApiKey = "xyz";
            string emptySteamId = "";

            // Act
            var result = await profileService.CreateProfile(emptyName, invalidApiKey, emptySteamId);

            // Assert
            Assert.False(result.Success);
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Profilname", result.ErrorMessage);
            Assert.Contains("Steam API Key", result.ErrorMessage);
            Assert.Contains("Steam ID", result.ErrorMessage);

            // Verifizieren, dass AddAsync niemals aufgerufen wurde
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Domain.DataObjects.UserProfile>()), Times.Never);
        }

        [Fact]
        public async Task CreateProfile_WrongInput_www()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string invalidName = "me";  // Leerzeichen oder ung�ltig
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
        public async Task CreateProfile_WrongInput_rww()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string validName = "TestUser";  // valider Name
            string invalidApiKey = "xyz"; // Kein valider Key
            string invalidSteamId = "123456"; // Falsches Format

            // Act
            var result = await profileService.CreateProfile(validName, invalidApiKey, invalidSteamId);

            // Assert
            Assert.False(result.Success); // Die Erstellung darf nicht erfolgreich sein
            Assert.NotNull(result.ErrorMessage);
            Assert.DoesNotContain("Profilname", result.ErrorMessage);
            Assert.Contains("API Key", result.ErrorMessage);
            Assert.Contains("Steam ID", result.ErrorMessage);

            // Verifizieren, dass AddAsync niemals aufgerufen wurde
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Domain.DataObjects.UserProfile>()), Times.Never);
        }

        [Fact]
        public async Task CreateProfile_WrongInput_wrw()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string invalidName = "me";  // kein valider Name
            string validApiKey = "VALIDAPIKEY112233445566778899001"; // valider Key
            string invalidSteamId = "123456"; // Falsches Format

            // Act
            var result = await profileService.CreateProfile(invalidName, validApiKey, invalidSteamId);

            // Assert
            Assert.False(result.Success); // Die Erstellung darf nicht erfolgreich sein
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Profilname", result.ErrorMessage);
            Assert.DoesNotContain("API Key", result.ErrorMessage);
            Assert.Contains("Steam ID", result.ErrorMessage);

            // Verifizieren, dass AddAsync niemals aufgerufen wurde
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Domain.DataObjects.UserProfile>()), Times.Never);
        }

        [Fact]
        public async Task CreateProfile_WrongInput_wwr()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string invalidName = "me";  // kein valider Name
            string invalidApiKey = "xyz"; // Kein valider Key
            string validSteamId = "76561198000000000"; // valides Format

            // Act
            var result = await profileService.CreateProfile(invalidName, invalidApiKey, validSteamId);

            // Assert
            Assert.False(result.Success); // Die Erstellung darf nicht erfolgreich sein
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Profilname", result.ErrorMessage);
            Assert.Contains("API Key", result.ErrorMessage);
            Assert.DoesNotContain("Steam ID", result.ErrorMessage);

            // Verifizieren, dass AddAsync niemals aufgerufen wurde
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Domain.DataObjects.UserProfile>()), Times.Never);
        }

        [Fact]
        public async Task CreateProfile_WrongInput_wrr()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string invalidName = "me";  // kein valider Name
            string validApiKey = "VALIDAPIKEY112233445566778899001"; // valider Key
            string validSteamId = "76561198000000000"; // valides Format

            // Act
            var result = await profileService.CreateProfile(invalidName, validApiKey, validSteamId);

            // Assert
            Assert.False(result.Success); // Die Erstellung darf nicht erfolgreich sein
            Assert.NotNull(result.ErrorMessage);
            Assert.Contains("Profilname", result.ErrorMessage);
            Assert.DoesNotContain("API Key", result.ErrorMessage);
            Assert.DoesNotContain("Steam ID", result.ErrorMessage);

            // Verifizieren, dass AddAsync niemals aufgerufen wurde
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Domain.DataObjects.UserProfile>()), Times.Never);
        }

        [Fact]
        public async Task CreateProfile_WrongInput_rwr()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string validName = "TestUser";  // valider Name
            string invalidApiKey = "xyz"; // Kein valider Key
            string validSteamId = "76561198000000000"; // valides Format

            // Act
            var result = await profileService.CreateProfile(validName, invalidApiKey, validSteamId);

            // Assert
            Assert.False(result.Success); // Die Erstellung darf nicht erfolgreich sein
            Assert.NotNull(result.ErrorMessage);
            Assert.DoesNotContain("Profilname", result.ErrorMessage);
            Assert.Contains("API Key", result.ErrorMessage);
            Assert.DoesNotContain("Steam ID", result.ErrorMessage);

            // Verifizieren, dass AddAsync niemals aufgerufen wurde
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Domain.DataObjects.UserProfile>()), Times.Never);
        }

        [Fact]
        public async Task CreateProfile_WrongInput_rrw()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var profileService = new ProfileService(mockRepo.Object);

            string validName = "TestUser";  // valider Name
            string validApiKey = "VALIDAPIKEY112233445566778899001"; // valider Key
            string invalidSteamId = "123456"; // kein valides Format

            // Act
            var result = await profileService.CreateProfile(validName, validApiKey, invalidSteamId);

            // Assert
            Assert.False(result.Success); // Die Erstellung darf nicht erfolgreich sein
            Assert.NotNull(result.ErrorMessage);
            Assert.DoesNotContain("Profilname", result.ErrorMessage);
            Assert.DoesNotContain("API Key", result.ErrorMessage);
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
            string validSteamID = "76561198000000000"; // G�ltige SteamID64

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