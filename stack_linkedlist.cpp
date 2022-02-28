#include<iostream>

using namespace std;

struct Node{
    int data;
    Node *next;
};
typedef struct Node *stack;

bool IsEmpty(stack s){
    return(s == NULL); 
}
Node *createNode(int data){
    Node*p = new Node();
    if(p == NULL){
        return NULL;
    }
    p-> data = data;
    p -> next = NULL;
    return p;
}
void Push(stack &s, int data){
    Node *ptr = createNode(data); // Tao node moi
    if(IsEmpty(s)){
        s = ptr;
    }
    else{
        ptr -> next = s;
        s = ptr;
    }
}
int top(stack s){
    if(!IsEmpty(s)){
        return s -> data;
    }
    else cout << "Stack is empty" << endl;
}
int pop(stack &s){
    if(!IsEmpty(s)){
        int data = s -> data;
        Node *x = s;
        s = s -> next;
        delete(x);
        return data;
    }
    else cout << "Stack is empty" << endl;

}
int main()
{
    stack s;
    Push(s, 100);
    Push(s, 99);
    Push(s, 35);
    cout << "TOP : " << top(s) << endl;
    pop(s); // xoa 1 phan tu o tren top cua stack
    while(!IsEmpty(s)){
        int data = top(s);
        pop(s);
        cout << data << " <--";
    }
    cout << endl;
    return 0;
}
