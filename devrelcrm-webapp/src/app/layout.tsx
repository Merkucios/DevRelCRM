import Navbar from '@/components/Navbar'
import Footer from '@/components/Footer'

import { Container } from 'react-bootstrap'
import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import './globals.css'

const inter = Inter({ subsets: ['latin'] })

export const metadata: Metadata = {
  title: 'DevRelCRM',
  icons: '/icon-site.png',
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
          <Footer />
        </main>
      </body>
    </html>
  )
}
