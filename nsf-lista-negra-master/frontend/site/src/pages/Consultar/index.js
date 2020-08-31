

import React, { useState, useRef, useEffect } from 'react';
import LoadingBar from 'react-top-loading-bar';

import ListaNegraApi from '../../services/listaNegraApi'
import { Link } from 'react-router-dom';
const api = new ListaNegraApi();


export default function Consultar() {
    const loadingBar = useRef(null);

    const [registros, setRegistros] = useState([])

    const consultarClick = async () => {
        loadingBar.current.continuousStart();

        const lns = await api.consultar()
        setRegistros([...lns])

        loadingBar.current.complete();
    }


    const deletarClick = async (id) => {
        const deletado = await api.deletar(id)
        await consultarClick();
    }


    useEffect(() => {
        consultarClick();
    }, [])


    return (
        <div>
            <LoadingBar
                height={4}
                color='#f11946'
                ref={loadingBar}
                />

            <h1>Consultar na Lista Negra</h1>

            <div>
                <button onClick={consultarClick}> Consultar </button>
            </div>

            <div>
                <table className="table">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th></th>
                            <th>Nome</th>
                            <th>Motivo</th>
                            <th>Local</th>
                            <th>Inclusão</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>

                    <tbody>
                        {registros.map(item => 
                            <tr key={item.id}>
                                <th>#{item.id}</th>
                                <td>
                                   <img src={api.buscarImagem(item.foto)} alt="" height="32" />
                                </td>
                                <td>{item.nome}</td>
                                <td>{item.motivo}</td>
                                <td>{item.local}</td>
                                <td> {new Date(item.inclusao + 'Z').toLocaleString() }</td>
                                <td>
                                    <button onClick={() => deletarClick(item.id)}>
                                        Deletar
                                    </button>
                                </td>
                                <td>
                                    <Link to={{
                                        pathname: "/alterar",
                                        state: item
                                    }}
                                     >
                                         Alterar
                                    </Link>
                                </td>
                            </tr>    
                        )}
                    </tbody>
                </table>
            </div>
        </div>
    )
}