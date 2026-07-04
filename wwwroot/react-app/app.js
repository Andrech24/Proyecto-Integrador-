const { useEffect, useState } = React;

function App() {
  const [tareas, setTareas] = useState([]);
  const [form, setForm] = useState({
    titulo: "",
    descripcion: "",
    materia: "",
    fechaEntrega: new Date(Date.now() + 86400000).toISOString().slice(0, 10)
  });

  async function cargarTareas() {
    const respuesta = await fetch("/api/tareas");
    setTareas(await respuesta.json());
  }

  useEffect(() => {
    cargarTareas();
  }, []);

  async function crearTarea(event) {
    event.preventDefault();
    await fetch("/api/tareas", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form)
    });
    setForm({ ...form, titulo: "", descripcion: "" });
    await cargarTareas();
  }

  return (
    React.createElement("section", { className: "shell" },
      React.createElement("header", null,
        React.createElement("p", { className: "eyebrow" }, "Cliente React"),
        React.createElement("h1", null, "Consumo de API JSON"),
        React.createElement("p", null, "Esta pantalla obtiene y crea tareas usando /api/tareas.")
      ),
      React.createElement("form", { onSubmit: crearTarea, className: "panel" },
        React.createElement("input", {
          placeholder: "Titulo",
          value: form.titulo,
          onChange: e => setForm({ ...form, titulo: e.target.value }),
          required: true
        }),
        React.createElement("input", {
          placeholder: "Materia",
          value: form.materia,
          onChange: e => setForm({ ...form, materia: e.target.value }),
          required: true
        }),
        React.createElement("input", {
          type: "date",
          value: form.fechaEntrega,
          onChange: e => setForm({ ...form, fechaEntrega: e.target.value }),
          required: true
        }),
        React.createElement("textarea", {
          placeholder: "Descripcion",
          value: form.descripcion,
          onChange: e => setForm({ ...form, descripcion: e.target.value })
        }),
        React.createElement("button", { type: "submit" }, "Crear tarea")
      ),
      React.createElement("div", { className: "grid" },
        tareas.map(tarea =>
          React.createElement("article", { className: "card", key: tarea.id },
            React.createElement("span", { className: "badge" }, `Prioridad ${tarea.prioridad}`),
            React.createElement("h2", null, tarea.titulo),
            React.createElement("p", null, tarea.descripcion),
            React.createElement("footer", null, `${tarea.materia} | ${new Date(tarea.fechaEntrega).toLocaleDateString()} | ${tarea.estado}`)
          )
        )
      )
    )
  );
}

ReactDOM.createRoot(document.getElementById("root")).render(React.createElement(App));
