import { ReactNode } from 'react'

const MaxWidthWrapper = ({
  className,
  children,
}: {
  className?: string
  children: ReactNode
}) => {
  return (
    <div 
    className={
        `container mx-auto px-2.5 md:px-20 ${className}`
        }>
      {children}
    </div>
  )
}

export default MaxWidthWrapper