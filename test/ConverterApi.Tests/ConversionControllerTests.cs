using System.Threading.Tasks;
using ConverterApi.Controllers;
using ConverterApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedData;

namespace ConverterApi.Tests;

[TestClass]
public class ConversionControllerTests
{

    private readonly ILogger<TemperatureConversionController> _loggerMock =
        new Mock<ILogger<TemperatureConversionController>>().Object;
    private readonly IHistoryService _historyServiceMock = 
        new Mock<IHistoryService>().Object;

    [TestMethod]
    public  void ConversionController_NullRequest_ReturnsBadRequest()
    {
        var conversionCalculatorMock = new Mock<IConversionCalculator>();

        var subjectUnderTest = new TemperatureConversionController(
            _loggerMock,
            conversionCalculatorMock.Object,
            _historyServiceMock);

        var result =  subjectUnderTest.ConvertTemperature(null);
        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
    }
    [TestMethod]
    public void ConversionController_FromUnits_NotSpecified_ReturnsBadRequest()
    {
        var conversionCalculatorMock = new Mock<IConversionCalculator>();

        var subjectUnderTest = new TemperatureConversionController(
            _loggerMock,
            conversionCalculatorMock.Object,
            _historyServiceMock);

        var input = new ConversionRequest { FromUnits = EnumTemperatureUnit.NotSpecified };
        var result =  subjectUnderTest.ConvertTemperature(input);
        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
    }

}