import React from "react";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import { Line } from "react-chartjs-2";
import moment from "moment";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

// const options = {
//   // scales: {
//   //         x: {
//   //             type: 'time',
//   //             time: {
//   //                 unit: 'month'
//   //             }
//   scales: {
//     x: {
//       type: "time",
//       time: {
//         unit: "month",
//       },
//     },
//   },
// };

export default function HosoChart({ chartData }) {
  // console.log("chartData", chartData);
  const options = {
    responsive: true,
    plugins: {
      scales: {
        x: [
          {
            gridLines: { display: false },
            distribution: "linear",

            type: "time",
            min: "2021-12-27 00:00:00",
            max: "2022-1-12 00:00:00",
            // moment(new Date(2022, 1 - 1, 12)).format("MM/DD/YYYY")
          },
        ],
      },
    },
  };
  // let mapData = [];
  // let countData = [];

  // chartData.map((item, index) => {
  //   mapData.push(new Date(item.day.year, item.day.month, item.day.day));
  //   countData.push(item.tongperDay);
  // });

  // console.log(mapData);

  let testDate = [
    // new Date(2021, 12, 30),
    // new Date(2021, 12, 31),
    // new Date(2022, 1, 1),
    // new Date(2022, 1, 2),
    // new Date(2022, 1, 3),
    // moment(new Date(2021, 12, 30)).format("MM/DD/YYYY"),
    // moment(new Date(2021, 12, 31)).format("MM/DD/YYYY"),
    // moment(new Date(2022, 1, 1)).format("MM/DD/YYYY"),
    // moment(new Date(2022, 1, 2)).format("MM/DD/YYYY"),
    // moment(new Date(2022, 1, 3)).format("MM/DD/YYYY"),
  ];

  chartData.map((item) =>
    testDate.push(
      moment(new Date(item.day.year, item.day.month - 1, item.day.day)).format(
        "MM/DD/YYYY"
      )
    )
  );

  const testCount = [1, 3, 5, 7, 9];
  const data = {
    labels: testDate,
    datasets: [
      {
        label: " Hồ sơ ",
        data: chartData.map((item, index) => item.tongperDay),
        borderColor: "rgb(255, 99, 132)",
        backgroundColor: "rgba(255, 99, 132, 0.5)",
      },
    ],
  };
  return (
    <div>
      <Line options={options} data={data} height="100%" />
    </div>
  );
}
