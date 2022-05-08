using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedData;

namespace ConverterApi.Tests
{
    [TestClass]
    public class ConversionCalculatorTests
    {

        [DataTestMethod]
        [DataRow("", EnumTemperatureUnit.NotSpecified, "No value to convert")]
        [DataRow("ABC", EnumTemperatureUnit.NotSpecified, "Value 'ABC' not a number")]
        [DataRow("100", EnumTemperatureUnit.NotSpecified, "Cannot convert from NotSpecified")]
        [DataRow("100", EnumTemperatureUnit.Celsius, null)]
        [DataRow("-500", EnumTemperatureUnit.Fahrenheit, "Value is below absolute zero. This is a mathematical result only and cannot describe a physical universe temperature.")]
        public void ConversionCalculator_Result_Message_conditions(string inputValue, EnumTemperatureUnit fromUnits,
            string expectedMessage)
        {
            var testData = new ConversionRequest
            {
                Value = inputValue,
                FromUnits = fromUnits
            };
            var systemUnderTest = new ConversionCalculator();
            var result = systemUnderTest.Convert(testData);
            Assert.AreEqual(expectedMessage, result.Message);
        }

        [DataTestMethod]
        [DataRow("100", EnumTemperatureUnit.Celsius, "212")]
        [DataRow("32", EnumTemperatureUnit.Fahrenheit, "32")]
        [DataRow("273.15", EnumTemperatureUnit.Kelvin, "32")]
        public void ConversionCalculator_Result_FahrenheitValues_Correct(string inputValue, EnumTemperatureUnit fromUnits,
            string expectedFahrenheit)
        {
            var testData = new ConversionRequest
            {
                Value = inputValue,
                FromUnits = fromUnits
            };
            var systemUnderTest = new ConversionCalculator();
            var result = systemUnderTest.Convert(testData);
            Assert.AreEqual(expectedFahrenheit, result.FahrenheitValue);
        }
    }
}
