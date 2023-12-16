import React from "react";
import ReactApexChart from "react-apexcharts";
import { lineChartData, lineChartOptions } from "@/variables/charts";

interface LineChartProps { }

interface LineChartState {
    chartData: any; 
    chartOptions: any; 
  }

  class LineChart extends React.Component<LineChartProps, LineChartState> {
  constructor(props: LineChartProps) {
    super(props);

    this.state = {
      chartData: [],
      chartOptions: {},
    };
  }

  componentDidMount() {
    this.setState({
      chartData: lineChartData,
      chartOptions: lineChartOptions,
    });
  }

  render() {
    return (
      <ReactApexChart
        options={this.state.chartOptions}
        series={this.state.chartData}
        type="area"
        width="100%"
        height="100%"
      />
    );
  }
}

export default LineChart;
