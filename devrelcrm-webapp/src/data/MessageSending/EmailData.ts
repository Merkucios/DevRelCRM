export interface EmailData {
    to: string[];
    bcc?: string[];
    cc?: string[];
    from?: string;
    displayName?: string;
    replyTo?: string;
    replyToName?: string;
    subject: string;
    body?: string;
    attachments?: FormData;
  }