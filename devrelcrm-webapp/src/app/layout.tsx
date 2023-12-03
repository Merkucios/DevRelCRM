import Navbar from '@/components/Navbar'

import { Container, Nav } from 'react-bootstrap'
import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import './globals.css'

const inter = Inter({ subsets: ['latin'] })

export const metadata: Metadata = {
  title: 'DevRelCRM',
  icons: '/favicon.ico',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <main className='d-flex flex-column min-vh-100'>
          <Navbar />
          <Container fluid className='flex-grow-1'>
            {children}
          </Container>
        </main>
      </body>
    </html>
  )
}
