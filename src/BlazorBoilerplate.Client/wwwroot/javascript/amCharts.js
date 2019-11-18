window.amChartsJsFunctions = {
    myChart: null,

    createAmChartSample: function() {

        // if (window.amChartsJsFunctions.myChart) {
        //      window.amChartsJsFunctions.myChart.dispose();
        // }

        this.resetAmChart();

        var chart = am4core.create("chartdiv", am4charts.PieChart);
        this.myChart = chart;

        // Create pie series
        var series = chart.series.push(new am4charts.PieSeries());
        series.dataFields.value = "litres";
        series.dataFields.category = "country";

        // Add data
        chart.data = [{
            "country": "Lithuania",
            "litres": 501.9
        }, {
            "country": "Czech Republic",
            "litres": 301.9
        }, {
            "country": "Ireland",
            "litres": 201.1
        }, {
            "country": "Germany",
            "litres": 165.8
        }, {
            "country": "Australia",
            "litres": 139.9
        }, {
            "country": "Austria",
            "litres": 128.3
        }, {
            "country": "UK",
            "litres": 99
        }, {
            "country": "Belgium",
            "litres": 60
        }, {
            "country": "The Netherlands",
            "litres": 50
        }];

        // And, for a good measure, let's add a legend
        chart.legend = new am4charts.Legend();
    },

    createAmChartXySample: function() {

        this.resetAmChart();

        var chart = am4core.create("chartdiv", am4charts.XYChart);
        this.myChart = chart;

        // Add data
        chart.data = [{
          "country": "Lithuania",
          "litres": 501.9,
          "units": 250
        }, {
          "country": "Czech Republic",
          "litres": 301.9,
          "units": 222
        }, {
          "country": "Ireland",
          "litres": 201.1,
          "units": 170
        }, {
          "country": "Germany",
          "litres": 165.8,
          "units": 122
        }, {
          "country": "Australia",
          "litres": 139.9,
          "units": 99
        }, {
          "country": "Austria",
          "litres": 128.3,
          "units": 85
        }, {
          "country": "UK",
          "litres": 99,
          "units": 93
        }, {
          "country": "Belgium",
          "litres": 60,
          "units": 50
        }, {
          "country": "The Netherlands",
          "litres": 50,
          "units": 42
        }];

        // Create axes
        let categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
        categoryAxis.dataFields.category = "country";
        categoryAxis.title.text = "Countries";

        let valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.title.text = "Litres sold (M)";

        // Create series
        var series = chart.series.push(new am4charts.ColumnSeries());
        series.dataFields.valueY = "litres";
        series.dataFields.categoryX = "country";
        series.name = "Sales";
        series.columns.template.tooltipText = "Series: {name}\nCategory: {categoryX}\nValue: {valueY}";
        series.columns.template.fill = am4core.color("#00ff00"); // fill

        var series2 = chart.series.push(new am4charts.LineSeries());
        series2.name = "Units";
        series2.stroke = am4core.color("#CDA2AB");
        series2.strokeWidth = 3;
        series2.dataFields.valueY = "units";
        series2.dataFields.categoryX = "country";

    },

    setChartData: function(chartData) {
        console.log(chartData);
        if (this.myChart) {
            console.log('setting chart data');
            this.myChart.data = chartData;
        }
    },

    resetAmChart: function() {
        if (this.myChart) {
            this.myChart.dispose();
        }

        this.myChart = null;
    },

    dumpParameters: function(value) {
        console.log(value);

    },

    

};