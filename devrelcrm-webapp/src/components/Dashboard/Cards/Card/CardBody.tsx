import { Box, useStyleConfig, BoxProps } from "@chakra-ui/react";
import React, { ReactNode } from 'react';

interface CardProps extends BoxProps {
  variant?: string; 
}
function CardBody(props: CardProps): ReactNode {
  const { variant, children, ...rest } = props;
  const styles = useStyleConfig("CardBody", { variant });
  return (
    <Box __css={styles} {...rest}>
      {children}
    </Box>
  );
}

export default CardBody;
