import axios from "axios";

const API = axios.create({
    baseURL: "https://api.mlsadpu.com",
});

export const Auth = async (email, password) => {
    const params = {
        email: email,
        password: password,
    };

    try {
        const response = await API.post("/auth", JSON.stringify(params), {
            headers: {
                "Content-Type": "application/json",
            },
        });
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const IsLogged = async (token) => {
    const params = {
        token: token
    };

    try {
        const response = await API.post("/IsLogged", JSON.stringify(params), {
            headers: {
                "Content-Type": "application/json",
            },
        });
        localStorage.removeItem("token");
        return response.data;
    } catch (error) {
        localStorage.removeItem("token");
        throw error.response.data;
    }
};