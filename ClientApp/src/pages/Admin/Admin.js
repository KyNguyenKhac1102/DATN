import React, { useEffect, useState } from "react";

import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import "./Admin.css";
import Card from "@mui/material/Card";
import {
  CardContent,
  CircularProgress,
  Typography,
  Backdrop,
  Button,
  Modal,
} from "@mui/material";
import axios from "axios";
import maChuyenNganh from "../../data/maChuyenNganh.json";
import tinhData from "../../data/tinh.json";
import doituongData from "../../data/doiTuongUuTien.json";
import khuvucData from "../../data/khuVucUuTien.json";
import { Box } from "@mui/system";
import { Line } from "react-chartjs-2";
import HosoChart from "./User/components/HosoChart";
import BarChartNganhChart from "./User/components/BarChartNganh";
import BarchartTinh from "./User/components/BarchartTinh";
import BarchartDoituong from "./User/components/BarcharDoituong";
import BarchartKhuvuc from "./User/components/BarchartKhuvuc";

export default function Admin() {
  const [loading, setLoading] = useState(false);
  const [tonghop, setTonghop] = useState({
    tonghopInfo: {
      tongHoso: "",
      tongHoso_diemcao: "",
      tongHoso_dtutien: "",
      tongHoso_khuvucutien: "",
      hosoPerDay: [
        {
          day: {
            year: "",
            month: "",
            day: "",
          },
          tongperDay: "",
        },
      ],
    },
    tongBestNv_Nganh: "",
  });

  const [listNganh, setListNganh] = useState([]);
  const [openListNganh, setOpenListNganh] = useState(false);

  const [listTinh, setListTinh] = useState([]);
  const [openListTinh, setOpenListTinh] = useState(false);

  const [listDoituong, setListDoituong] = useState([]);
  const [openListDoituong, setOpenListDoituong] = useState(false);

  const [listKhuvuc, setListKhuvuc] = useState([]);
  const [openListKhuvuc, setOpenListKhuvuc] = useState(false);

  const handleTonghopNganh = () => {
    axios
      .get("api/TongHop/nganh")
      .then((res) => {
        setListNganh(res.data);
        setOpenListNganh(true);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const handleTonghopTinh = () => {
    axios
      .get("api/TongHop/tinh")
      .then((res) => {
        setListTinh(res.data);
        setOpenListTinh(true);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const handleTonghopDoituong = () => {
    axios
      .get("api/TongHop/doituong")
      .then((res) => {
        setListDoituong(res.data);
        setOpenListDoituong(true);
        console.log("doituong", res.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const handleTonghopKhuvuc = () => {
    axios
      .get("api/TongHop/khuvuc")
      .then((res) => {
        setListKhuvuc(res.data);
        setOpenListKhuvuc(true);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const handleTonghoso = () => {
    //set
  };

  const handleCloseListNganh = () => setOpenListNganh(false);
  const handleCloseListTinh = () => setOpenListTinh(false);
  const handleCloseListDoituong = () => setOpenListDoituong(false);
  const handleCloseListKhuvuc = () => setOpenListKhuvuc(false);

  const getTonghopData = () => {
    setLoading(true);
    axios.get("api/TongHop").then((res) => {
      setTonghop(res.data);
      setLoading(false);
      console.log("data", res.data);
    });
  };

  useEffect(() => {
    getTonghopData();
  }, []);

  const style = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: "70%",
    height: "60%",
    bgcolor: "white",
    border: "2px solid #000",
    boxShadow: 24,
    p: 4,
  };

  return (
    <div className="Admin">
      <Backdrop open={loading}>
        <CircularProgress color="inherit" />
      </Backdrop>
      <Modal open={openListNganh} onClose={handleCloseListNganh}>
        <Box sx={style}>
          <BarChartNganhChart nganhData={listNganh} />
        </Box>
      </Modal>
      <Modal open={openListTinh} onClose={handleCloseListTinh}>
        <Box sx={style}>
          <BarchartTinh tinhData={listTinh} />
        </Box>
      </Modal>
      <Modal open={openListDoituong} onClose={handleCloseListDoituong}>
        <Box sx={style}>
          <BarchartDoituong doiTuongData={listDoituong} />
        </Box>
      </Modal>
      <Modal open={openListKhuvuc} onClose={handleCloseListKhuvuc}>
        <Box sx={style}>
          <BarchartKhuvuc khuVucData={listKhuvuc} />
        </Box>
      </Modal>
      <Header />
      <div style={{ display: "flex", height: "100vh" }}>
        <Sidebar />
        <div className="container">
          <div
            style={{
              minWidth: 250,
              height: 150,
              display: "flex",
              justifyContent: "space-around",
              width: "100%",
              paddingTop: 20,
            }}
          >
            <Card sx={{ minWidth: 250, height: 150, background: "#1c98b8" }}>
              <CardContent>
                <div className="title-card"> Hồ sơ nhận được</div>
                <div className="content-card">
                  {" "}
                  {tonghop.tonghopInfo.tongHoso}
                </div>
                {/* <div className="button-card">
                  {" "}
                  <Button
                    sx={{ color: "white" }}
                    onClick={handleTonghopDoituong}
                    variant="inherit"
                  >
                    View Detail
                  </Button>
                </div> */}
              </CardContent>
            </Card>
            <Card sx={{ minWidth: 250, height: 150, background: "#1c98b8" }}>
              <CardContent>
                <div className="title-card"> Ngành HOT </div>
                <div className="content-card"> {tonghop.tongBestNv_Nganh}</div>
                <div className="button-card">
                  {" "}
                  <Button
                    sx={{ color: "white" }}
                    onClick={handleTonghopNganh}
                    variant="inherit"
                  >
                    View Detail
                  </Button>
                </div>
              </CardContent>
            </Card>
            {/* <Card sx={{ minWidth: 250, height: 150, background: "#1c98b8" }}>
              <CardContent>
                <div className="title-card"> Tỉnh </div>
                <div className="content-card"> {tonghop.}</div>
                <div className="button-card">
                  {" "}
                  <Button
                    sx={{ color: "white" }}
                    onClick={handleTonghopTinh}
                    variant="inherit"
                  >
                    View Detail
                  </Button>
                </div>
              </CardContent>
            </Card> */}
            <Card sx={{ minWidth: 250, height: 150, background: "#1c98b8" }}>
              <CardContent>
                <div className="title-card"> Hồ sơ ĐT ưu tiên</div>
                <div className="content-card">
                  {" "}
                  {tonghop.tonghopInfo.tongHoso_dtutien}
                </div>
                <div className="button-card">
                  {" "}
                  <Button
                    sx={{ color: "white" }}
                    onClick={handleTonghopDoituong}
                    variant="inherit"
                  >
                    View Detail
                  </Button>
                </div>
              </CardContent>
            </Card>
            <Card sx={{ minWidth: 250, height: 150, background: "#1c98b8" }}>
              <CardContent>
                <div className="title-card"> Hồ sơ KV ưu tiên</div>
                <div className="content-card">
                  {" "}
                  {tonghop.tonghopInfo.tongHoso_khuvucutien}
                </div>
                <div className="button-card">
                  {" "}
                  <Button
                    sx={{ color: "white" }}
                    onClick={handleTonghopKhuvuc}
                    variant="inherit"
                  >
                    View Detail
                  </Button>
                </div>
              </CardContent>
            </Card>
            {/* <Card sx={{ minWidth: 250, height: 150, background: "#1c98b8" }}>
              <CardContent>
                <div className="title-card"> Hồ sơ KV ưu tiên</div>
                <div className="content-card">
                  {" "}
                  {tonghop.tonghopInfo.tongHoso_khuvucutien}
                </div>
                <div className="button-card">
                  {" "}
                  <Button
                    sx={{ color: "white" }}
                    onClick={handleTonghopDoituong}
                    variant="inherit"
                  >
                    View Detail
                  </Button>
                </div>
              </CardContent>
            </Card> */}
          </div>
          <div className="container-tonghopper">
            {/* <div className="title-text">DANH SÁCH TỔNG HỢP</div>
            <Button
              sx={{ margin: "5px" }}
              onClick={handleTonghopNganh}
              variant="contained"
            >
              Tổng hợp theo từng ngành
            </Button>
            <div>
              <Button
                sx={{ margin: "5px" }}
                onClick={handleTonghopTinh}
                variant="contained"
              >
                Tổng hợp theo từng thành phố
              </Button>
            </div>
            <div>
              <Button
                sx={{ margin: "5px" }}
                onClick={handleTonghopDoituong}
                variant="contained"
              >
                Tổng hợp theo từng đối tượng
              </Button>
            </div>
            <div>
              <Button
                sx={{ margin: "5px" }}
                onClick={handleTonghopKhuvuc}
                variant="contained"
              >
                Tổng hợp theo từng khu vực
              </Button>
            </div> */}
            <HosoChart chartData={tonghop.tonghopInfo.hosoPerDay} />
          </div>
        </div>
      </div>
    </div>
  );
}
