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
import khuVucJson from "../../../../data/khuVucUuTien.json";
ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  BarElement,
  Title,
  Tooltip,
  Legend
);

export default function BarchartKhuvuc({ khuVucData }) {
  console.log("khuVucData", khuVucData);
  const options = {
    responsive: true,
  };

  const data = {
    labels: khuVucData.map((item) => khuVucJson[item.khuvuc]),
    datasets: [
      {
        label: "Hồ sơ",
        data: khuVucData.map((item, index) => item.tongperKhuvuc),
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
