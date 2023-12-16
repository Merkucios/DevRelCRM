import { ApexOptions } from "apexcharts";

export const barChartData = [
    {
      name: "Кол-во пользователей",
      data: [813, 617, 431, 315, 204],
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
      categories: ["Вконтакте", "Телеграм", "Ютуб", "Хабр", "HeadHunter"],
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
  
  export const lineChartData = [
    {
      name: "Mobile apps",
      data: [50, 40, 300, 220, 500, 250, 400, 230, 500],
    },
    {
      name: "Websites",
      data: [30, 90, 40, 140, 290, 290, 340, 230, 400],
    },
  ];
  
  export const lineChartOptions = {
    chart: {
      toolbar: {
        show: false,
      },
    },
    tooltip: {
      theme: "dark",
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      curve: "smooth",
    },
    xaxis: {
      type: "datetime",
      categories: [
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "May",
        "Jun",
        "Jul",
        "Aug",
        "Sep",
        "Oct",
        "Nov",
        "Dec",
      ],
      axisTicks: {
        show: false
      },
      axisBorder: {
        show: false,
      },
      labels: {
        style: {
          colors: "#fff",
          fontSize: "12px",
        },
      },
    },
    yaxis: {
      labels: {
        style: {
          colors: "#fff",
          fontSize: "12px",
        },
      },
    },
    legend: {
      show: false,
    },
    grid: {
      strokeDashArray: 5,
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        type: "vertical",
        shadeIntensity: 0.5,
        inverseColors: true,
        opacityFrom: 0.8,
        opacityTo: 0,
        stops: [],
      },
      colors: ["#fff", "#3182CE"],
    },
    colors: ["#fff", "#3182CE"],
  };
  