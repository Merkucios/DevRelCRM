import React, { Component, ReactNode } from "react";
import Chart from "react-apexcharts";
import { ApexOptions } from "apexcharts";

interface PieChartProps {
  chartData: number[];
  chartOptions: ApexOptions;
}

interface PieChartState {
  chartData: number[];
  chartOptions: ApexOptions;
}

class PieChart extends Component<PieChartProps, PieChartState> {
  constructor(props: PieChartProps) {
    super(props);
    this.state = {
      chartData: [] as number[],
    chartOptions: {} as ApexOptions,
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
        type="pie"
        width="100%"
        height="100%"
      />
    );
  }
}

export default PieChart;
