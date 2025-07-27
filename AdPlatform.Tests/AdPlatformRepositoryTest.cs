namespace AdPlatform.Tests;

public class AdPlatformRepositoryTest
{
    [Fact]
    public void SearchPlatformTest()
    {
        // Arrange
        var adPlatformRepository = new AdPlatformRepository();

        var lines = new string[]
        {
            "Яндекс.Директ:/ru",
            "Ревдинский рабочий:/ru/svrd/svrdrevda,/ru/svrd/pervik",
            "Газета уральских москвичей:/ru/msk,/ru/permobl,/ru/chelobl",
            "Крутая реклама:/ru/svrd",
        };

        adPlatformRepository.LoadFromLines(lines);


        // Act
        var ru = adPlatformRepository.SearchPlatform("/ru");

        var svrd = adPlatformRepository.SearchPlatform("/ru/svrd");

        var svrdrevda = adPlatformRepository.SearchPlatform("/ru/svrd/svrdrevda");

        var rumsk = adPlatformRepository.SearchPlatform("/ru/msk");

        // Assert
        Assert.Equal("Яндекс.Директ", ru[0]);

        Assert.Equal("Яндекс.Директ", svrd[0]);
        Assert.Equal("Крутая реклама", svrd[1]);

        Assert.Equal("Яндекс.Директ", svrdrevda[0]);
        Assert.Equal("Ревдинский рабочий", svrdrevda[1]);
        Assert.Equal("Крутая реклама", svrdrevda[2]);

        Assert.Equal("Яндекс.Директ", rumsk[0]);
        Assert.Equal("Газета уральских москвичей", rumsk[1]);
    }
}