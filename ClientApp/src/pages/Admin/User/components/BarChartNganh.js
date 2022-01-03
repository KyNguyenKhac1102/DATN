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

import maChuyenNganh from "../../../../data/maChuyenNganh.json";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  BarElement,
  Title,
  Tooltip,
  Legend
);

export default function BarChartNganhChart({ nganhData }) {
  console.log("nganhData", nganhData);
  const options = {
    responsive: true,
  };

  const data = {
    labels: nganhData.map((item) => item.nganh),
    datasets: [
      {
        label: "Nguyện vọng",
        data: nganhData.map((item, index) => item.tongperNganh),
        borderColor: "rgb(255, 99, 132)",
        backgroundColor: "rgba(53, 162, 235, 0.5)",
      },
    ],
  };
  return (
    <div>
      <Bar options={options} data={data} height="100%" />
    </div>
  );
}
