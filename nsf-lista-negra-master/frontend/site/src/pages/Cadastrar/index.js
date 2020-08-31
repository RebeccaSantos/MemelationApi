

import React, { useState } from 'react';
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';


import ListaNegraApi from "../../services/listaNegraApi";
const api = new ListaNegraApi();


export default function Cadastrar() {
    const [nome, setNome] = useState('')
    const [motivo, setMotivo] = useState('')
    const [inclusao, setInclusao] = useState('')
    const [local, setLocal] = useState('')
    const [foto, setFoto] = useState();

    const salvarClick = async () => {
        try {
            const request = {
                nome,
                motivo,
                local,
                inclusao,
                foto
            };
            const resp = await api.cadastrar(request);
            toast.dark('🚀 Cadastrado na lista negra');
        } catch (e) {
            if (e.response.data.erro)
                toast.error(e.response.data.erro);
            else 
                toast.error('Ocorreu um erro. Tente novamente.');
        }
    }
    
    return (
        <div>
            <h1>Cadastrar na Lista Negra</h1>

            <div>
                <label>Nome:</label>
                <input type="text" 
                  value={nome}
                  onChange={e => setNome(e.target.value)}
                 />
            </div>

            <div>
                <label>Motivo:</label>
                <input type="text" 
                   value={motivo}
                   onChange={e => setMotivo(e.target.value)}
                  />
            </div>

            <div>
                <label>Local:</label>
                <select
                   value={local}
                   onChange={e => setLocal(e.target.value)} >
                    
                    <option value="Família">Família</option>
                    <option value="Escola">Escola</option>
                    <option value="Trabalho">Trabalho</option>
                    <option value="Outro">Outro</option>
                </select>
                  
            </div>

            <div>
                <label>Foto:</label>
                <input type="file" 
                   onChange={e => setFoto(e.target.files[0])}
                  />
            </div>

            <div>
                <label>Inclusão:</label>
                <input type="date" 
                   value={inclusao}
                   onChange={e => setInclusao(e.target.value)}
                  />
            </div>

            

            <div>
                <button onClick={salvarClick}> Cadastrar </button>
            </div>

            <ToastContainer />
        </div>
    )
}