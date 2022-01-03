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
import doiTuongJson from "../../../../data/doiTuongUuTien.json";
ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  BarElement,
  Title,
  Tooltip,
  Legend
);

export default function BarchartDoituong({ doiTuongData }) {
  console.log("doiTuongData", doiTuongData);
  const options = {
    responsive: true,
  };

  const data = {
    labels: doiTuongData.map((item) => doiTuongJson[item.doituong]),
    datasets: [
      {
        label: "Hồ sơ",
        data: doiTuongData.map((item, index) => item.tongperDoituong),
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
