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
    try {
        const response = await API.get("/IsLogged", {
            headers: {
                "Authorization": "Bearer " + token
            },
        });
        return response.data;
    } catch (error) {
        localStorage.removeItem("token");
        throw error.response.data;
    }
};

export const GetCity = async () => {
    try {
        const response = await API.get("/City", {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            },
        });
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const GetCounty = async (id) => {
    try {
        const response = await API.get(`/County/${id}`, {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            },
        });
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const GetDistrict = async (id) => {
    try {
        const response = await API.get(`/District/${id}`, {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            },
        });
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const FilterWithId = async (query) => {
    try {
        const response = await API.get(`/Advert/AdvertFilterWithId?${query}`, {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            },
        });
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};