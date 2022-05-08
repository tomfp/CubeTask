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

    [TestMethod]
    public async Task ConversionController_NullRequest_ReturnsBadRequest()
    {
        var conversionCalculatorMock = new Mock<IConversionCalculator>();

        var subjectUnderTest = new TemperatureConversionController(
            _loggerMock,
            conversionCalculatorMock.Object);

        var result = await subjectUnderTest.ConvertTemperature(null);
        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
    }
    [TestMethod]
    public async Task ConversionController_FromUnits_NotSpecified_ReturnsBadRequest()
    {
        var conversionCalculatorMock = new Mock<IConversionCalculator>();

        var subjectUnderTest = new TemperatureConversionController(
            _loggerMock,
            conversionCalculatorMock.Object);

        var input = new ConversionRequest { FromUnits = EnumTemperatureUnit.NotSpecified };
        var result = await subjectUnderTest.ConvertTemperature(input);
        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
    }

}