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
        const response = await API.get("/City");
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const GetCounty = async (id) => {
    try {
        const response = await API.get(`/County/${id}`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const GetDistrict = async (id) => {
    try {
        const response = await API.get(`/District/${id}`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};

export const FilterWithId = async (datas) => {
    try {
        const response = await API.get(`/Advet/AdvertFilterWithId?advertTypeId=${datas.advertTypeId}&cityId=${datas.cityId}&countyId=${datas.countyId}&districtId=${datas.districtId}`);
        return response.data;
    } catch (error) {
        throw error.response.data;
    }
};