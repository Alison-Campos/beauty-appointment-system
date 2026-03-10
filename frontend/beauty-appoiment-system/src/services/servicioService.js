const API_URL = "https://localhost:7138/api/Servicios";

export const servicioService = {
  ObtenerServicios: async () => {
    const response = await fetch(`${API_URL}/ServicioObtenerTodos`);
    return await response.json();
  },

  obtenerServicioPorId: async (id) => {
    const response = await fetch(`${API_URL}/ServicioObtenerPorId/${id}`);
    return await response.json();
  },

  CrearServicio: async (servicio) => {
    const response = await fetch(`${API_URL}/ServicioCrear`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(servicio),
    });
    const data = await response.json();

    if (!response.ok) {
      throw new Error(data.mensaje);
    }
    return data;
  },

  actualizarServicio: async (id, servicio) => {
    await fetch(`${API_URL}/ServicioActualizar/${id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(servicio),
    });
  },

  eliminarServicio: async (id) => {
    await fetch(`${API_URL}/ServicioEliminar/${id}`, {
      method: "DELETE",
    });
  },
};
