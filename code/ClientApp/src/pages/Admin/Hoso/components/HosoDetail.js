import {
  Alert,
  Button,
  Card,
  CardContent,
  CardMedia,
  Grid,
  Modal,
  Snackbar,
  TextField,
  Typography,
} from "@mui/material";
import axios from "axios";
import { FastField, Form, Formik } from "formik";
import React, { useEffect, useState } from "react";
import * as yup from "yup";
import CustomField from "../../../../components/FormsUI/CustomField";
import { useParams } from "react-router-dom";
import doiTuongUuTien from "../../../../data/doiTuongUuTien.json";
import khuVucUuTien from "../../../../data/khuVucUuTien.json";
import tinh from "../../../../data/tinh.json";
import maChuyenNganh from "../../../../data/maChuyenNganh.json";
import toHop from "../../../../data/toHop.json";
import "./HosoDetail.css";
import { Box } from "@mui/system";

const styleModal = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
};

export default function HosoDetail() {
  let { id } = useParams();

  const [serverData, setServerData] = useState({
    id: "",
    userId: "",
    hoTen: "",
    ngaySinh: "",
    gioiTinh: "",

    soDienThoai: "",
    soCCCD: "",
    email: "",
    diaChiHoKhau: "",
    maKhuVuc: "",
    maDoiTuong: "",

    tinh10Id: "",
    truongLop10Id: "",

    tinh11Id: "",
    truongLop11Id: "",

    tinh12Id: "",
    truongLop12Id: "",

    diaChiLienHe: "",

    hoTenBo: "",
    sdtBo: "",

    hoTenMe: "",
    sdtMe: "",

    hocba10_url: "",
    hocba11_url: "",
    hocba12_url: "",

    studentNguyenVongs: [
      {
        stt_NguyenVong: "",
        maNganh: "",
        maToHop: "",
      },
    ],

    diemToan10: "",
    diemLy10: "",
    diemHoa10: "",

    diemToan11: "",
    diemLy11: "",
    diemHoa11: "",

    diemToan12: "",
    diemLy12: "",
    diemHoa12: "",
    diemTb_UuTien: "",
  });

  const [truong10, setTruong10] = useState("");
  const [truong11, setTruong11] = useState("");
  const [truong12, setTruong12] = useState("");

  const [open, setOpen] = React.useState(false);
  const [open11, setOpen11] = React.useState(false);
  const [open12, setOpen12] = React.useState(false);
  const handleOpen = () => {
    setOpen(true);
  };
  const handleOpen11 = () => {
    setOpen11(true);
  };
  const handleOpen12 = () => {
    setOpen12(true);
  };
  const handleClose = () => {
    setOpen(false);
  };
  const handleClose11 = () => {
    setOpen11(false);
  };
  const handleClose12 = () => {
    setOpen12(false);
  };

  const getHosoDetail = () => {
    axios
      .get(`api/StudentInfo/${id}`)
      .then((res) => {
        console.log(res.data);

        setServerData(res.data);

        getTruong10ById(res.data.truongLop10Id);
        getTruong11ById(res.data.truongLop11Id);
        getTruong12ById(res.data.truongLop12Id);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  const getTruong10ById = (truongid) => {
    axios.get(`/api/Truong/${truongid}`).then((res) => {
      console.log(res.data);
      setTruong10(res.data.tenTruong);
    });
  };

  const getTruong11ById = (truongid) => {
    axios.get(`/api/Truong/${truongid}`).then((res) => {
      console.log(res.data);
      setTruong11(res.data.tenTruong);
    });
  };

  const getTruong12ById = (truongid) => {
    axios.get(`/api/Truong/${truongid}`).then((res) => {
      console.log(res.data);
      setTruong12(res.data.tenTruong);
    });
  };

  useEffect(() => {
    getHosoDetail();
  }, []);

  return (
    <>
      {" "}
      <Modal open={open} onClose={handleClose}>
        <Box sx={{ ...styleModal, width: 600 }}>
          <img
            src={serverData.hocba10_url}
            alt="hocba10"
            width={600}
            height={600}
          />
        </Box>
      </Modal>
      <Modal open={open11} onClose={handleClose11}>
        <Box sx={{ ...styleModal, width: 600 }}>
          <img
            src={serverData.hocba11_url}
            alt="hocba10"
            width={600}
            height={600}
          />
        </Box>
      </Modal>
      <Modal open={open12} onClose={handleClose12}>
        <Box sx={{ ...styleModal, width: 600 }}>
          <img
            src={serverData.hocba12_url}
            alt="hocba10"
            width={600}
            height={600}
          />
        </Box>
      </Modal>
      <div
        style={{
          height: "90%",
          width: "85%",
          paddingTop: 20,
          paddingLeft: 50,
        }}
      >
        <Typography
          sx={{
            fontSize: 24,
            fontWeight: 550,
            borderBottom: "1px solid",
            paddingBottom: "5px",
            width: 200,
          }}
        >
          H??? S?? CHI TI???T
        </Typography>
        {/* <Grid container spacing={2}>
                  <Grid item xs={12}>
                    <Typography>Th??ng tin th?? sinh</Typography>
                  </Grid>
                  </Grid> */}
        <div style={{ display: "flex" }} className="flex-container">
          <div>
            {" "}
            <div className="title">TH??NG TIN C?? NH??N</div>
            <Typography>ID: {serverData.id}</Typography>
            <Typography>H??? t??n: {serverData.hoTen}</Typography>
            <Typography>Ng??y sinh: {serverData.ngaySinh}</Typography>
            <Typography>Gi???i t??nh: {serverData.gioiTinh}</Typography>
            <Typography>S??? CMND/CCCD: {serverData.soCCCD}</Typography>
            <Typography>S??? ??i???n Tho???i: {serverData.soDienThoai}</Typography>
            <Typography>?????a ch??? h??? kh???u: {serverData.diaChiHoKhau}</Typography>
            <Typography>
              ?????i t?????ng: {doiTuongUuTien[serverData.maDoiTuong]}
            </Typography>
            <Typography>
              Khu V???c: {khuVucUuTien[serverData.maKhuVuc]}
            </Typography>
            <div className="title">TH??NG TIN TR?????NG</div>
            <Typography>T???nh l???p 10: {tinh[serverData.tinh10Id]}</Typography>
            <Typography>T???nh l???p 11: {tinh[serverData.tinh11Id]}</Typography>
            <Typography>T???nh l???p 12: {tinh[serverData.tinh12Id]}</Typography>
            <Typography>Tr?????ng l???p 10: {truong10}</Typography>
            <Typography>Tr?????ng l???p 11: {truong11}</Typography>
            <Typography>Tr?????ng l???p 12: {truong12}</Typography>
          </div>
          <div>
            <div className="title">TH??NG TIN LI??N H???</div>
            <Typography>?????a ch??? li??n h???: {serverData.diaChiLienHe}</Typography>
            <Typography>H??? t??n b???: {serverData.hoTenBo}</Typography>
            <Typography>S??? ??i???n tho???i B???: {serverData.sdtBo}</Typography>
            <Typography>H??? t??n M???: {serverData.hoTenMe}</Typography>
            <Typography>S??? ??i???n tho???i M???: {serverData.sdtMe}</Typography>
            <div className="title-diem">??I???M</div>
            <div style={{ display: "flex", justifyContent: "space-between" }}>
              <div className="diem-container">
                <Typography>??i???m To??n 10: {serverData.diemToan10}</Typography>
                <Typography>??i???m L?? 10: {serverData.diemLy10}</Typography>
                <Typography>??i???m H??a 10: {serverData.diemHoa10}</Typography>
                <Typography>??i???m To??n 11: {serverData.diemToan11}</Typography>
                <Typography>??i???m L?? 11: {serverData.diemLy11}</Typography>
                <Typography>??i???m H??a 11: {serverData.diemHoa11}</Typography>
                <Typography>??i???m To??n 12:{serverData.diemToan12}</Typography>
                <Typography>??i???m L?? 12: {serverData.diemLy12}</Typography>
                <Typography>??i???m H??a 12: {serverData.diemHoa12}</Typography>
              </div>
              <div className="tongdiem-container">
                <h5>??i???m x??t tuy???n:</h5>
                <div>{serverData.diemTb_UuTien}</div>
              </div>
            </div>
          </div>
        </div>
        <div>
          <div className="title-2">NGUY???N V???NG</div>
          {serverData.studentNguyenVongs.map((nv, index) => (
            <div key={nv.stt_NguyenVong} className="nguyenvong-container">
              <TextField value={nv.stt_NguyenVong} label="Nguyen Vong" />
              <TextField
                value={maChuyenNganh[nv.maNganh]}
                label="Nganh"
                style={{ paddingLeft: 5, width: 450 }}
              />
              <TextField
                value={toHop[nv.maToHop]}
                label="To Hop"
                className="space"
                style={{ paddingLeft: 5 }}
              />
            </div>
          ))}
        </div>
        <div>
          <div className="title-2"> ???NH H???C B??? </div>
        </div>

        <div
          style={{
            display: "flex",
            justifyContent: "space-between",
            width: "85%",
          }}
        >
          <Card sx={{ maxWidth: 345 }}>
            <CardMedia
              component="img"
              height="300"
              image={serverData.hocba10_url}
              alt="hocba10"
              onClick={handleOpen}
            />
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                H???c b??? l???p 10
              </Typography>
            </CardContent>
          </Card>

          <Card sx={{ maxWidth: 345 }}>
            <CardMedia
              component="img"
              height="300"
              image={serverData.hocba11_url}
              alt="hocba11"
              onClick={handleOpen11}
            />
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                H???c b??? l???p 11
              </Typography>
            </CardContent>
          </Card>

          <Card sx={{ maxWidth: 345 }}>
            <CardMedia
              component="img"
              height="300"
              image={serverData.hocba12_url}
              alt="hocba12"
              onClick={handleOpen12}
            />
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                H???c b??? l???p 12
              </Typography>
            </CardContent>
          </Card>
        </div>
      </div>
    </>
  );
}
