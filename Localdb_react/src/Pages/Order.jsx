import { useState, useEffect } from "react";
import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import DeleteForeverRoundedIcon from "@mui/icons-material/DeleteForeverRounded";
import Snackbar from "@mui/material/Snackbar";
import Alert from "@mui/material/Alert";
import EditNoteIcon from "@mui/icons-material/EditNote";
import "./Style.css";

function Order() {
  //GET

  const [box, setBox] = useState([]);
  const fetchdata = async () => {
    try {
      const response = await fetch("https://localhost:7132/api/order");
      const res = await response.json();
      setBox(res);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    fetchdata();
  }, ["https://localhost:7132/api/order"]);

  //POST

  const [orderName, setOrder] = useState("");
  const [price, setPrice] = useState("");
  const [selectedOrder, setSelectedOrder] = useState(null);

  const handleSubmit = async () => {
    const data = {
      orderName,
      price,
    };
    setOrder("");
    setPrice("");

    try {
      const response = await fetch("https://localhost:7132/api/order", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (response.ok) {
        handleClick("Order was successfully Created!");
      } else {
        console.error("Something went wrong");
      }
      fetchdata();
    } catch (error) {
      console.error("Error during fetch:", error);
    }
  };

  //DELETE
  const deletebutton = async (id) => {
    try {
      const respsone = await fetch(`https://localhost:7132/api/order/${id}`, {
        method: "DELETE",
      }).then((response) => {
        if (!response.ok) {
          throw new Error("Something went wrong");
        }
      });
      fetchdata();
    } catch (error) {
      console.log(error);
    }
  };

  //UPDATE
  const updatebutton = (contact) => {
    setSelectedOrder(contact);
    setOrder(contact.orderName);
    setPrice(contact.price);
  };

  const handleUpdate = async () => {
    if (!selectedOrder) return;

    const data = {
      id: selectedOrder.id,
      orderName: orderName,
      price: price,
    };

    try {
      const response = await fetch(
        `https://localhost:7132/api/order/${selectedOrder.id}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        }
      );

      if (response.ok) {
        console.log("Data updated successfully");
        handleClick("Data updated successfully");
        setSelectedOrder(null);
        setOrder("");
        setPrice("");
      } else {
        handleClick("Something went wrong");
      }
      fetchdata();
    } catch (error) {
      console.error("Error during fetch:", error);
      handleClick("Error during fetch");
    }
  };

  //SNACKBAR

  const [open, setOpen] = React.useState(false);
  const [snackbarMessage, setSnackbarMessage] = useState("");

  const handleClick = (message) => {
    setSnackbarMessage(message);
    setOpen(true);
  };

  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setOpen(false);
  };

  return (
    <TableContainer component={Paper} sx={{ marginTop: 3, padding: 3 }}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead className="tablehead">
          <TableRow>
            <TableCell align="left">Order's</TableCell>
            <TableCell align="left">Price</TableCell>
            <TableCell align="right">Edit </TableCell>
            <TableCell align="left">Delete</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {box.map((row) => (
            <TableRow
              key={row.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell>{row.orderName}</TableCell>
              <TableCell>{row.price}</TableCell>
              <TableCell align="right">
                <Button sx={{ m: 0 }} onClick={() => updatebutton(row)}>
                  <EditNoteIcon />
                </Button>
              </TableCell>
              <TableCell align="left">
                <Button sx={{ m: 0 }} onClick={() => deletebutton(row.id)}>
                  <DeleteForeverRoundedIcon />
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <Box
        component="form"
        sx={{ "& > :not(style)": { m: 1, width: "25ch" } }}
        noValidate
        autoComplete="off"
      >
        <div className="form">
          <TextField
            id="order"
            label="Create new order"
            variant="standard"
            value={orderName}
            onChange={(e) => setOrder(e.target.value)}
          />
          <TextField
            id="price"
            label="Price"
            variant="standard"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
          />
          <Button
            sx={{ m: 2 }}
            variant="contained"
            onClick={selectedOrder ? handleUpdate : handleSubmit}
          >
            {selectedOrder ? "Update" : "Submit"}
          </Button>
          <Snackbar open={open} autoHideDuration={4000} onClose={handleClose}>
            <Alert
              onClose={handleClose}
              severity="success"
              variant="filled"
              sx={{ width: "100%" }}
            >
              {snackbarMessage}
            </Alert>
          </Snackbar>
        </div>
      </Box>
    </TableContainer>
  );
}

export default Order;
