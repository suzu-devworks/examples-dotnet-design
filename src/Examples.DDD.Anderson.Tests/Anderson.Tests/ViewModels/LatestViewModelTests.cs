using Examples.DDD.Anderson.Entities;
using Examples.DDD.Anderson.Helpers;
using Examples.DDD.Anderson.Repositories;

namespace Examples.DDD.Anderson.ViewModels.Tests;

public class LatestViewModelTests
{
    [Fact]
    public void TestMeasureScenario()
    {
        var measureMock = new Mock<IMeasureRepository>();
        var measure = new MeasureEntity("guidA", "2017/01/01 13:00:00".ToDate(), 1.23456f);
        measureMock.Setup(x => x.GetLatest()).Returns(measure);

        var viewModel = new LatestViewModel(measureMock.Object);
        viewModel.MeasureDate.Is("2017/01/01 13:00:00");
        viewModel.MeasureValue.Is("1.23m/s");
        return;
    }

    [Fact]
    public void TestMeasureScenarioWithFake()
    {
        var viewModel = new LatestViewModel();
        viewModel.MeasureDate.Is("2017/01/01 13:00:00");
        viewModel.MeasureValue.Is("1.23m/s");
        return;
    }

}

