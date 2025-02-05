import { useState, useEffect } from "react";
import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import DeleteForeverRoundedIcon from "@mui/icons-material/DeleteForeverRounded";
import Button from "@mui/material/Button";

function Role() {
  const [box, setBox] = useState([]);
  useEffect(() => {
    fetch("https://localhost:7132/api/role")
      .then((res) => {
        return res.json();
      })
      .then((data) => {
        setBox(data);
        console.log(data);
      });
  }, []);

  return (
    <TableContainer component={Paper}>
      Role's
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Roles</TableCell>
            <TableCell align="right">Delete</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {box.map((row) => (
            <TableRow
              key={row.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.roleName}
              </TableCell>
              <TableCell align="right">
                <Button>
                  <DeleteForeverRoundedIcon />
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default Role;
