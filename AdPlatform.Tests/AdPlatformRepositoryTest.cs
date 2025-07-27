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
            "������.������:/ru",
            "���������� �������:/ru/svrd/svrdrevda,/ru/svrd/pervik",
            "������ ��������� ���������:/ru/msk,/ru/permobl,/ru/chelobl",
            "������ �������:/ru/svrd",
        };

        adPlatformRepository.LoadFromLines(lines);


        // Act
        var ru = adPlatformRepository.SearchPlatform("/ru");

        var svrd = adPlatformRepository.SearchPlatform("/ru/svrd");

        var svrdrevda = adPlatformRepository.SearchPlatform("/ru/svrd/svrdrevda");

        var rumsk = adPlatformRepository.SearchPlatform("/ru/msk");

        // Assert
        Assert.Equal("������.������", ru[0]);

        Assert.Equal("������.������", svrd[0]);
        Assert.Equal("������ �������", svrd[1]);

        Assert.Equal("������.������", svrdrevda[0]);
        Assert.Equal("���������� �������", svrdrevda[1]);
        Assert.Equal("������ �������", svrdrevda[2]);

        Assert.Equal("������.������", rumsk[0]);
        Assert.Equal("������ ��������� ���������", rumsk[1]);
    }
}