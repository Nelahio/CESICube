import React from 'react'
import { GiDelicatePerfume } from 'react-icons/gi'

export default function Navbar() {
    return (
        <header className='
        sticky top-0 z-50 flex justify-between bg-white p-5 items-center text-gray-800 shadow-md
        '>
            <div className='flex items-center gap-2 text-3xl font-semibold text-red-500'>
                <GiDelicatePerfume size={34} />
                <div>CESI Enchères</div>
            </div>
            <div>Rechercher</div>
            <div>Login</div>
        </header>
    )
}