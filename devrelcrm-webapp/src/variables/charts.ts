import { ApexOptions } from "apexcharts";

export const barChartData = [
    {
      name: "Кол-во пользователей",
      data: [813, 617, 431, 315, 204, 402],
    },
  ];
  
  export const barChartOptions : ApexOptions  = {
    chart: {
      toolbar: {
        show: true,
      },
    },
    tooltip: {
      theme: "dark",
    },
    xaxis: {
        title: {
            text: "Сервисы привлечения аудитории", 
            style: {
              fontSize: "12px",
              color: "#82878d", 
            },
          },
      categories: ["Вконтакте", "Телеграм", "Ютуб", "Хабр", "HeadHunter", "Codenrock"],
      labels: {
        style: {
          colors: "#343639",
          fontSize: "12px",
        },
      },
      axisBorder: {
        show: false,
      },
      
    },
    yaxis: {
        title: {
            text: "Кол-во пользователей", 
            style: {
              fontSize: "12px",
              color: "#82878d", 
            },
          },
      show: true,
      labels: {
        show: true,
        style: {
          colors: "#343639",
          fontSize: "16px",
        },
      },
    },
    fill: {
    },
    dataLabels: {
      enabled: false,
    },
    grid: {
      strokeDashArray: 5,
    },
    plotOptions: {
      bar: {
        borderRadius: 15,
        columnWidth: "15px",
      },
    },
    responsive: [
      {
        breakpoint: 768,
        options: {
          plotOptions: {
            bar: {
              borderRadius: 0,
            },
          },
        },
      },
    ],
  };
  
  export const pieChartData = [
    {
      name: "Team A",
      data: [813, 617, 431, 315, 204, 402],
    },
  ];

  export const pieChartOptions : ApexOptions  = {
      chart: {
        type: 'pie',
      },
      tooltip: {
        theme: "dark",
      },
      labels: ['Team A', 'Team B', 'Team C', 'Team D', 'Team E'],
      responsive: [{
        breakpoint: 480,
        options: {
          chart: {
            width: 200
          },
          legend: {
            position: 'bottom'
          }
        }
      }]
  };