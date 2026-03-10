import { useEffect, useState } from "react";
import { servicioService } from "../../services/servicioService";

const API = "https://localhost:7138/api/Servicios";

function ServiciosPage() {
  const [servicios, setServicios] = useState([]);
  const [form, setForm] = useState({
    Nombre: "",
    Precio: "",
    DuracionMin: "",
    ColorCalendario: "#ff69b4",
  });

  const [editando, setEditando] = useState(null);

  useEffect(() => {
    cargarServicios();
  }, []);

  const cargarServicios = async () => {
    const data = await servicioService.ObtenerServicios();
    setServicios(data);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;

    setForm({
      ...form,
      [name]:
        name === "Precio" || name === "DuracionMin" ? Number(value) : value,
    });
  };

  const guardar = async () => {
    try {
      if (editando) {
        await servicioService.actualizarServicio(editando, form);
      } else {
        await servicioService.CrearServicio(form);
      }

      limpiar();
      cargarServicios();
    } catch (error) {
      alert(error.message);
    }
  };

  const editar = (servicio) => {
    setForm({
      Nombre: servicio.nombre,
      Precio: servicio.precio,
      DuracionMin: servicio.duracionMin,
      ColorCalendario: servicio.colorCalendario,
    });

    setEditando(servicio.idServicio);
  };

  const eliminar = async (id) => {
    if (!window.confirm("¿Eliminar servicio?")) return;

    await servicioService.eliminarServicio(id);

    cargarServicios();
  };

  const limpiar = () => {
    setForm({
      Nombre: "",
      Precio: "",
      DuracionMin: "",
      ColorCalendario: "#ff69b4",
    });

    setEditando(null);
  };

  return (
    <div>
      <h2>Servicios</h2>

      <div className="form-grid">
        <input
          name="Nombre"
          placeholder="Nombre servicio"
          value={form.Nombre}
          onChange={handleChange}
        />

        <input
          name="Precio"
          type="number"
          placeholder="Precio"
          value={form.Precio}
          onChange={handleChange}
        />

        <input
          name="DuracionMin"
          type="number"
          placeholder="Duración (min)"
          value={form.DuracionMin}
          onChange={handleChange}
        />

        <input
          type="color"
          name="colorCalendario"
          value={form.ColorCalendario}
          onChange={handleChange}
        />
      </div>

      <div style={{ display: "flex", gap: "10px", marginTop: "10px" }}>
        <button className="btn-primary" onClick={guardar}>
          {editando ? "Actualizar" : "Guardar"}
        </button>

        <button className="btn-secondary" onClick={limpiar}>
          Cancelar
        </button>
      </div>

      <hr style={{ margin: "30px 0" }} />

      <table>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Precio</th>
            <th>Duración</th>
            <th>Color</th>
            <th></th>
          </tr>
        </thead>

        <tbody>
          {servicios.map((s) => (
            <tr key={s.idServicio}>
              <td>{s.nombre}</td>

              <td>${s.precio}</td>

              <td>{s.duracionMin} min</td>

              <td>
                <div
                  style={{
                    width: 20,
                    height: 20,
                    borderRadius: 5,
                    background: s.colorCalendario,
                  }}
                />
              </td>

              <td>
                <button className="btn-edit" onClick={() => editar(s)}>
                  Editar
                </button>{" "}
                <button
                  className="btn-delete"
                  onClick={() => eliminar(s.idServicio)}
                >
                  Eliminar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ServiciosPage;
