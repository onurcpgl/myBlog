import axios from "axios";

export const loginAxios = async (value) => {
    const login = await axios({
        method: 'post',
        url: "https://localhost:7229/api/login",
        data: {
            emailAdress: "onurcpgl@gmail.com",
            password: "onur123"   
        }
    });
    return login;
}

