import { useEffect, useRef, useState } from "react";
import { addTodosAPI, delTodosAPI, editTodosAPI, getTodosAPI } from "../../api/todos";
import "./index.css";

const Todos = () => {
  const [todos, setTodos] = useState([]);
  const [textBt,setTextBt] = useState("Thêm mới")
  const todoref = useRef([]);
  const data = [];
  useEffect(() => {
    fetchData();
  }, []);
  const fetchData = async () => {
    setTodos(await getTodosAPI());
  };
  const delTodo = async (id) => {
    if (window.confirm("Nhiệm vụ không thể khôi phục. Chắc chắn muốn xóa?")) {
      await delTodosAPI(id);
      setTodos(todos.filter((todos) => todos.id !== id)); // Update state to remove the deleted task
    }
  };
  const addOrEditTodo = async (event) => {
    event.preventDefault();
    const val = event.target[0].value;
    const id = event.target[1].value;
    console.log({val,id});  
    if(id){
      await editTodosAPI({
        name : val,
        id : id
      })
      todoref.current[id].className = "fas fa-edit";
    } else{
      await addTodosAPI({
        name : val
      })
    }
    fetchData();
    event.target[0].value = "";
    event.target[1].value = null;
  }
  const handleItemClick = (id) => {
    todoref?.current.forEach((item) => {
      if (item.getAttribute("data-id") && item.getAttribute("data-id") !== String(id)){
        item.className = "fas fa-edit";
      }
    })
    const inputname = document.getElementById("name");
    const inputid = document.getElementById("id");
    if (todoref?.current[id].className === "fas fa-edit") {
      todoref.current[id].className = "fas fa-user-edit";
      setTextBt("Cập Nhật");
      inputname.value = todoref.current[id].getAttribute("data-name");
      inputid.value = id;
    } else if (todoref?.current[id].className === "fas fa-user-edit") {
      todoref.current[id].className = "fas fa-edit";
      inputname.value = "";
      inputid.value = null;
      setTextBt("Thêm Mới")
    }
  }
  const onIsCompleteTodo = async (todo) => {
    await editTodosAPI({
      ...todo,
      IsComplete : false
    });
    fetchData();
  }
  return (
    <main id="todolist">
      <h1>
        Danh sách
        <span>Việc hôm nay không để ngày mai.</span>
      </h1>
      {todos ? (
        todos?.map((item, key) => (
          <li
            className={item.IsComplete ? "done" : ""}
            key={key}
            onClick={() => onIsCompleteTodo(item)}
          >
            <span className="label">{item.name}</span>
            <div className="actions">
              <button className="btn-picto" type="button"
               onClick={() => handleItemClick(item.id)}>
                <i className="fas fa-edit"
                ref={el => todoref.current[item.id] = el}
                data-name = {item.name} 
                data-id = {item.id}/>
              </button>
              <button
                className="btn-picto"
                type="button"
                aria-label="Delete"
                title="Delete"
                onClick={() => delTodo(item.id)}
              >
                <i className="fas fa-trash" />
              </button>
            </div>
          </li>
        ))
      ) : (
        <p>Danh sách nhiệm vụ trống.</p>
      )}
      <form onSubmit={addOrEditTodo}>
        <label>Thêm nhiệm vụ mới</label>
        <input
          type="text"
          name="name"
          id="name"
        />
        <input
          type="text"
          name="id"
          id="id"
          style={{display : "none"}}
        />
        <button type="submit">{textBt}</button>
      </form>
    </main>
  );
};
export default Todos;
