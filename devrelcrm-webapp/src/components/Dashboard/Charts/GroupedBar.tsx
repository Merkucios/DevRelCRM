import { ApexOptions } from 'apexcharts';
import React, { useState } from 'react';
import ReactApexChart from 'react-apexcharts';

const GroupedBar = () => {
  const [chartData, setChartData] = useState({
    series: [
      {
        name: 'Значение до мероприятия',
        data: [35, 25, 26, 30, 14, 18, 5],
      },
      {
        name: 'Значение после мероприятия',
        data: [63, 32, 42, 33, 20, 26, 8],
      },
    ],
    options: {
      chart: {
        type: 'bar',
        height: 430,
      },
      plotOptions: {
        bar: {
          horizontal: true,
          dataLabels: {
            position: 'top',
          },
        },
      },
      dataLabels: {
        enabled: true,
        offsetX: -6,
        style: {
          fontSize: '12px',
          colors: ['#fff'],
        },
      },
      stroke: {
        show: true,
        width: 1,
        colors: ['#fff'],
      },
      tooltip: {
        shared: true,
        intersect: false,
      },
      xaxis: {
        categories: ["DevRel", "Frontend", "Backend", "DevOps", "Mobile", "UI/UX", "DataOps"],
      },
      title: {
        text: 'Привлечение новых специалистов 👓',
        align: 'center',
        style: {
          fontSize: '16px',
          fontWeight: 'bold',
        },
      },
    },
  });

  return (
    <div id="chart">
      <ReactApexChart options={chartData.options as ApexOptions} series={chartData.series} type="bar" height={430} />
    </div>
  );
};

export default GroupedBar;