import React, { Component, ReactNode } from "react";
import Chart from "react-apexcharts";
import { ApexOptions } from "apexcharts";

interface BarChartProps {
  chartData: ApexOptions["series"];
  chartOptions: ApexOptions;
}

interface BarChartState {
  chartData: ApexOptions["series"];
  chartOptions: ApexOptions;
}

class BarChart extends Component<BarChartProps, BarChartState> {
  constructor(props: BarChartProps) {
    super(props);
    this.state = {
      chartData: [],
      chartOptions: {},
    };
  }

  componentDidMount() {
    this.setState({
      chartData: this.props.chartData,
      chartOptions: this.props.chartOptions,
    });
  }

  render(): ReactNode {
    return (
      <Chart
        options={this.state.chartOptions}
        series={this.state.chartData}
        type="bar"
        width="100%"
        height="100%"
      />
    );
  }
}

export default BarChart;
