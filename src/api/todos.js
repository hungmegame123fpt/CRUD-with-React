import Todos from "../components/Todos";
import axiosClient from "./axiosClient";
const END_POINT = {
    TODOS: "todos",
}
export const getTodosAPI = () => {
    return axiosClient.get(`${END_POINT.TODOS}`);
}
export const delTodosAPI = (id) => {
    return axiosClient.delete(`${END_POINT.TODOS}/${id}`);
}
export const addTodosAPI = (todos) => {
    return axiosClient.post(`${END_POINT.TODOS}`, todos);  
}
export const editTodosAPI = (todos) => {
    return axiosClient.put(`${END_POINT.TODOS}`, todos); 
}