namespace SalonLib.Test;

public class ServiceLocatorTest
{
    [Fact]
    public void Service1Test()
    {
        var expected = "В кабинете";
        var actual = SalonLib.ServiceLocator.GetService("Читать стихи");
        Assert.Equal(expected, actual);
    }

}