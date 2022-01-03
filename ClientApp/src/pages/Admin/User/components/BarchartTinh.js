import React from "react";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  BarElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import { Bar } from "react-chartjs-2";
import tinhDataJson from "../../../../data/tinh.json";
ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  BarElement,
  Title,
  Tooltip,
  Legend
);

export default function BarchartTinh({ tinhData }) {
  console.log("tinhData", tinhData);
  const options = {
    responsive: true,
  };

  const data = {
    labels: tinhData.map((item) => tinhDataJson[item.tinh]),
    datasets: [
      {
        label: "Nguyện vọng",
        data: tinhData.map((item, index) => item.tongperTinh),
        borderColor: "rgb(255, 99, 132)",
        backgroundColor: "rgba(255, 99, 132, 0.5)",
      },
    ],
  };
  return (
    <div>
      <Bar options={options} data={data} height="100%" />
    </div>
  );
}
