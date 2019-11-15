﻿window.amChartsJsFunctions = {
    myChart: null,

    createAmChartSample: function() {

        if (window.amChartsJsFunctions.myChart) {
            window.amChartsJsFunctions.myChart.dispose();
        }
        
        var chart = am4core.create("chartdiv", am4charts.PieChart);
        window.amChartsJsFunctions.myChart = chart;

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
    }

};