using Moq;
using MyGolfApp.Authentication;
using MyGolfApp.Repository.Interfaces;
using MyGolfApp.Repository.Models;
using Xunit;

namespace MyGolfApp.Tests;

public class PasswordHasherTests
{
    private readonly Mock<IPasswordHasher> _passwordHasher;

    public PasswordHasherTests()
    {
        _passwordHasher = new Mock<IPasswordHasher>();
    }

    [Fact]
    public void EncryptPassword_ShouldReturnHashedPassword()
    {
        // Arrange
        var user = new Mock<IUser>();
        user.Setup(u => u.Id).Returns(1);
        var plainTextPassword = "mysecretpassword";
        var mockHashedPassword = "hashedPassword123";

        _passwordHasher
            .Setup(ph => ph.EncryptPassword(user.Object, plainTextPassword))
            .Returns(mockHashedPassword);

        // Act
        var hashedPassword = _passwordHasher.Object.EncryptPassword(user.Object, plainTextPassword);

        // Assert
        Assert.NotNull(hashedPassword);
        Assert.NotEqual(plainTextPassword, hashedPassword);
    }
    
    [Fact]
    public void VerifyHashedPassword_ShouldReturnTrueForValidPassword()
    {
        // Arrange
        var mockUser = new Mock<IUser>();
        mockUser.Setup(u => u.Id).Returns(1);
        var plainTextPassword = "mysecretpassword";
        var hashedPassword = "hashedPassword123";

        _passwordHasher
            .Setup(ph => ph.VerifyHashedPassword(mockUser.Object, hashedPassword, plainTextPassword))
            .Returns(true);

        // Act
        var isPasswordValid = _passwordHasher.Object.VerifyHashedPassword(mockUser.Object, hashedPassword, plainTextPassword);

        // Assert
        Assert.True(isPasswordValid);
        _passwordHasher.Verify(ph => ph.VerifyHashedPassword(mockUser.Object, hashedPassword, plainTextPassword), Times.Once);
    }

    [Fact]
    public void VerifyHashedPassword_ShouldReturnFalseForInvalidPassword()
    {
        // Arrange
        var mockUser = new Mock<IUser>();
        mockUser.Setup(u => u.Id).Returns(1);
        var plainTextPassword = "mysecretpassword";
        var wrongPassword = "wrongpassword";
        var hashedPassword = "hashedPassword123";

        _passwordHasher
            .Setup(ph => ph.VerifyHashedPassword(mockUser.Object, hashedPassword, wrongPassword))
            .Returns(false);

        // Act
        var isPasswordValid = _passwordHasher.Object.VerifyHashedPassword(mockUser.Object, hashedPassword, wrongPassword);

        // Assert
        Assert.False(isPasswordValid);
        _passwordHasher.Verify(ph => ph.VerifyHashedPassword(mockUser.Object, hashedPassword, wrongPassword), Times.Once);
    }
}