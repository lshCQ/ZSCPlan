package my_project;

public class Puppy {
	int puppyAge;
	public Puppy(String Name){
		System.out.println("小狗的名字是："+Name);
	};
	public void setAge(int age){
		puppyAge=age;
	};
	public int  getAge(){
		System.out.println("小狗的年龄为 : " + puppyAge ); 
	    return puppyAge;
	};
	public static void main(String[] args){
		Puppy myPuppy=new Puppy("tommy");
		myPuppy.setAge(28);
		myPuppy.getAge();
		System.out.println("变量值 : " + myPuppy.puppyAge ); 
	}
}
